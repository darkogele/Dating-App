using API.Helpers;
using System.Text.Json;

namespace API.Extensions;

public static class HttpExtensions
{
    private static readonly JsonSerializerOptions Options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public static void AddPaginationHeader<T>(this HttpResponse response, PagedList<T> Data)
    {
        var paginationHeader = new PaginationHeader(Data.CurrentPage, Data.PageSize,
            Data.TotalCount, Data.TotalPages, Data.HasPrevious, Data.HasNext);

        response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationHeader, Options));
        // response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
        response.Headers.AccessControlExposeHeaders = "Pagination";
    }
}