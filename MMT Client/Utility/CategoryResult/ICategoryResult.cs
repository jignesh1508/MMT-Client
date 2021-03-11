using System.Net.Http;

namespace MMT_Client.Utility
{
    public interface ICategoryResult
    {
        void Display(HttpResponseMessage response);
    }
}
