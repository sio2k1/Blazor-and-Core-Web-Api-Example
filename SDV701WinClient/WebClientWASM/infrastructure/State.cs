/*
 * Author: Oleg Sivers
 * Date: 06.06.2020
 * Desc: Represents application state
*/
using SDV701common;

namespace WebClientWASM.infrastructure
{
    public static class State
    {
        public static string previousPage = "/";
        public static NPart SelectedPart;
    }
}
