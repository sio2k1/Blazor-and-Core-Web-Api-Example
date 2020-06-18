using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SDV701BackEnd.DB;
using SDV701BackEnd.infrastructure;
using SDV701BackEnd.Protos;
using SDV701common;

namespace SDV701BackEnd
{
    public class NetshopService : Netshop.NetshopBase
    {
        private readonly ILogger<NetshopService> _logger;
        public NetshopService(ILogger<NetshopService> logger)
        {
            _logger = logger;
        }

        public override Task<GetHierarchicalJsonSerializedResponse> GetParts(GetAllRequest request, ServerCallContext context)
        {
            List<Type> tl = new List<Type> { typeof(NWiredWirelesspart), typeof(NWiredPart), typeof(NWirelesspart) };
            List<NPart> res = DB.DBExecuter.SQLToReader("select * from parts").MapHierarchy<NPart>(tl, "ClassName");
            //var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var json = utils.SerializeJsonWithTypes(res);

            return Task.FromResult(new GetHierarchicalJsonSerializedResponse
            {
                Assembly= utils.GetAssemblyNameByType<NPart>(), 
                SystemType=typeof(NPart).FullName,
                Response = json
            }); 
        }

        public override Task<GetJsonSerializedResponse> GetCategories(GetAllRequest request, ServerCallContext context)
        {
            string json = "";
            string error = "";
            try
            {
                List<Category> res = DB.DBExecuter.SQLToReader("exec sp_GetCategories").Map<Category>();
                json = JsonConvert.SerializeObject(res);
            } catch (Exception e)
            {
                error = e.GetBaseException().Message;
            }
            return Task.FromResult(new GetJsonSerializedResponse
            {
                Response = json,
                ErrorMessage = error
            });
        }

        public override Task<GetCategoryListHashResponse> GetCategoriesHash(GetAllRequest request, ServerCallContext context)
        {
            string res = "";
            string error = "";
            try
            {
                res = DB.DBExecuter.execScalar<string>("exec sp_GetCategoriesHash", new ParamList { });
            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
            }
            return Task.FromResult(new GetCategoryListHashResponse
            {
                Hash = res,
                Error = new basicResponse { ErrorResponse = error },
            });
        }

        public override Task<GetJsonSerializedResponse> GetOrders(GetAllRequest request, ServerCallContext context)
        {
            string json = "";
            string error = "";
            try
            {
                List<ClientOrder> res = DB.DBExecuter.SQLToReader("exec sp_GetOrders").Map<ClientOrder>();
                json = JsonConvert.SerializeObject(res);
            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
            }
            return Task.FromResult(new GetJsonSerializedResponse
            {
                Response = json,
                ErrorMessage = error
            });
        }
        public override Task<GetJsonSerializedResponse> GetPartsByCategoryId(GetByIdRequest request, ServerCallContext context)
        {
            string json = "";
            string error = "";
            try
            {
                List<Type> tl = new List<Type> { typeof(NWiredWirelesspart), typeof(NWiredPart), typeof(NWirelesspart) };
                List<NPart> res = DB.DBExecuter.SQLRequestSPAutoFillParams(
                    "sp_GetPartsByCategoryId", 
                    new DB.ParamList { ["CategoryId"]=request.Id }
                    ).MapHierarchy<NPart>(tl, "ClassName");
                json = utils.SerializeJsonWithTypes(res);
            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
            }
            return Task.FromResult(new GetJsonSerializedResponse
            {
                Response = json,
                ErrorMessage = error
            });
        }

        public override Task<DeleteUpdateResponse> Delete(SetRequest request, ServerCallContext context)
        {
            string error = "";
            int rows = -1;
            try
            {
                query DeleteQ = QueryGenerator.Delete(request.Assembly, request.SystemType, request.JSON, request.TPHType);
                rows = DBExecuter.execNonQuery(DeleteQ.sql, DeleteQ.paramList);

            } catch(Exception e)
            {
                error = e.GetBaseException().Message;
            }

            return Task.FromResult(
                new DeleteUpdateResponse
                {
                    Error = new basicResponse { ErrorResponse = error },
                    RowsAffected = rows

                }); ;
        }

        public override Task<DeleteUpdateResponse> Update(SetRequest request, ServerCallContext context)
        {
            string error = "";
            int rows = -1;
            try
            {
                query q = QueryGenerator.Update(request.Assembly, request.SystemType, request.JSON, request.TPHType);
                rows = DBExecuter.execNonQuery(q.sql, q.paramList);

            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
            }
            return Task.FromResult(
                new DeleteUpdateResponse
                {
                    Error = new basicResponse { ErrorResponse = error },
                    RowsAffected = rows
                }); ;
        }

        public override Task<InsertResponse> Insert(SetRequest request, ServerCallContext context)
        {
            string error = "";
            int idVal = -1;
            try
            {
                query q = QueryGenerator.Insert(request.Assembly, request.SystemType, request.JSON, request.TPHType);
                idVal = (int)DBExecuter.execScalar<int>(q.sql, q.paramList);

            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
            }

            return Task.FromResult(new InsertResponse
            {
                Error = new basicResponse { ErrorResponse= error },
                InsertedID = idVal
            });
        }

        public override Task<GetJsonSerializedResponse> GetPartById(GetByIdRequest request, ServerCallContext context)
        {
            string json = "";
            string error = "";
            try
            {
                List<Type> tl = new List<Type> { typeof(NWiredWirelesspart), typeof(NWiredPart), typeof(NWirelesspart) };
                List<NPart> res = DB.DBExecuter.SQLRequestSPAutoFillParams(
                    "sp_GetPartById",
                    new DB.ParamList { ["Id"] = request.Id }
                    ).MapHierarchy<NPart>(tl, "ClassName");
                json = utils.SerializeJsonWithTypes(res);
            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
            }
            return Task.FromResult(new GetJsonSerializedResponse
            {
                Response = json,
                ErrorMessage = error
            });
        }
        public override Task<InsertResponse> PlaceOrder(PlaceOrderRequest request, ServerCallContext context)
        {
            string error = "";
            int idVal = -1;
            try
            {
                //sp_PlaceOrder @PartsId int, @PartsQty int, @ClientName varchar(255), @ClientEmail varchar(255)

                ClientOrder validation = new ClientOrder { ClientEMail = request.ClientEMail, ClientName = request.ClientName, Quantity = request.PartsQty };
                string validationResult = validation.IsValid();

                if (validationResult == "")
                {
                    var pList = new DB.ParamList
                    {
                        ["PartsId"] = request.PartsId,
                        ["PartsQty"] = request.PartsQty,
                        ["ClientName"] = request.ClientName,
                        ["ClientEmail"] = request.ClientEMail
                    };


                    idVal = DB.DBExecuter.execScalarSPAutoFillParams("sp_PlaceOrder", pList); // raise an exception in case
                } else
                    throw new Exception($"Validation error: {validationResult}");



            }
            catch (Exception e)
            {
                error = e.GetBaseException().Message;
            }

            return Task.FromResult(new InsertResponse
            {
                Error = new basicResponse { ErrorResponse = error },
                InsertedID = idVal
            });
        }
    }
}
