/*
 * Author: Oleg Sivers
 * Date: 03.06.2020
 * Desc: gRPC client code to use within applications to send request and receive responses over gRPC
*/
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Newtonsoft.Json;
using SDV701BackEnd.Protos;
using SDV701common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static SDV701BackEnd.Protos.Netshop;

namespace grpcCalls
{
    public static class gRPCClient
    {
        public static string backEndAddress = "https://localhost:5001";
        public static bool webChannelMode = false; // set true for Blazor Wasm, default is false

        private static GrpcChannel GenerateChannel()
        {
            if (!webChannelMode)
                return GrpcChannel.ForAddress(backEndAddress);
            else
                return GrpcChannel.ForAddress(backEndAddress, new GrpcChannelOptions
                {
                    HttpHandler = new GrpcWebHandler(new HttpClientHandler())
                });
        }

        private static SetRequest RequestHelper(object obj, Type T, Type TPHtype)
        {
            return new SetRequest
            {
                Assembly = T.Assembly.GetName().Name,
                SystemType = T.FullName,
                JSON = utils.SerializeJsonWithTypes(obj),
                TPHType= TPHtype==null?"":TPHtype.Name
            };
        }

        public static async Task<int> Update(object obj, Type T, Type TPHtype = null)
        {
            using var channel = GenerateChannel();
            var client = new NetshopClient(channel);

            DeleteUpdateResponse res = await client.UpdateAsync(RequestHelper(obj, T, TPHtype));

            if (res.Error.ErrorResponse != "")
                throw new Exception(res.Error.ErrorResponse);
            return res.RowsAffected;
        }

        public static async Task<int> Insert(object obj, Type T, Type TPHtype = null)
        {
            using var channel = GenerateChannel();
            var client = new NetshopClient(channel);
            
            InsertResponse res = await client.InsertAsync(RequestHelper(obj, T, TPHtype));

            if (res.Error.ErrorResponse!="")
                throw new Exception(res.Error.ErrorResponse);
            return res.InsertedID;
        }

        public static async Task<int> Delete(object obj, Type T, Type TPHtype = null)
        {
            using var channel = GenerateChannel();
            var client = new NetshopClient(channel);
            
            DeleteUpdateResponse res = await client.DeleteAsync(RequestHelper(obj, T, TPHtype));

            if (res.Error.ErrorResponse != "")
                throw new Exception(res.Error.ErrorResponse);
            return res.RowsAffected;
        }

        public static async Task<List<T>> GetListOfPartsByCategoryId<T>(int CategoryId)
        {
            using var channel = GenerateChannel();
            var client = new NetshopClient(channel);

            var res = await client.GetPartsByCategoryIdAsync(new GetByIdRequest { Id = CategoryId });

            if (res.ErrorMessage != "")
                throw new Exception(res.ErrorMessage);     
            List<T> deserialized = utils.DeserializeJsonWithTypes<T>(res.Response);
            return deserialized;
        }

        public static async Task<NPart> GetPartsById(int PartId)
        {
            using var channel = GenerateChannel();
            var client = new NetshopClient(channel);

            var res = await client.GetPartByIdAsync(new GetByIdRequest { Id = PartId });

            if (res.ErrorMessage != "")
                throw new Exception(res.ErrorMessage);
            List<NPart> deserialized = utils.DeserializeJsonWithTypes<NPart>(res.Response);
            if (deserialized.Count!=1)
                throw new Exception("Something went wrong on selection NPart.");
            return deserialized.First();
        }

        public static async Task<List<Category>> GetListOfCategories()
        {
            var channel = GenerateChannel();
            var client = new NetshopClient(channel);

            var res = await client.GetCategoriesAsync(new GetAllRequest());

            if (res.ErrorMessage != "")
                throw new Exception(res.ErrorMessage);
            var deserialized = JsonConvert.DeserializeObject<List<Category>>(res.Response);
            return deserialized;
        }

        public static async Task<string> GetCategoriesHash()
        {

            var channel = GenerateChannel();
            var client = new NetshopClient(channel);

            var res = await client.GetCategoriesHashAsync(new GetAllRequest());

            if (res.Error.ErrorResponse != "")
                throw new Exception(res.Error.ErrorResponse);
            return res.Hash;
        }

        public static async Task<List<ClientOrder>> GetListOfOrders()
        {
            using var channel = GenerateChannel();
            var client = new NetshopClient(channel);

            var res = await client.GetOrdersAsync(new GetAllRequest());

            if (res.ErrorMessage != "")
                throw new Exception(res.ErrorMessage);
            var deserialized = JsonConvert.DeserializeObject<List<ClientOrder>>(res.Response);
            return deserialized;
        }

        public static async Task<int> PlaceOrder(int partsID, int partsQTY, string clientName, string clientEmail )
        {
            using var channel = GenerateChannel();
            var client = new NetshopClient(channel);
            var req = new PlaceOrderRequest{ PartsId = partsID, PartsQty = partsQTY, ClientName = clientName, ClientEMail= clientEmail };
            InsertResponse res = await client.PlaceOrderAsync(req);
            if (res.Error.ErrorResponse != "")
                throw new Exception(res.Error.ErrorResponse);
            return res.InsertedID;
        }
    }
}
