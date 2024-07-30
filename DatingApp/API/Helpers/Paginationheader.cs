namespace API.Helpers;

public class PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages, bool hasPrevious, bool hasNext)
{
    public int CurrentPage { get; set; } = currentPage;
    public int ItemsPerPage { get; set; } = itemsPerPage;
    public int TotalItems { get; set; } = totalItems;
    public int TotalPages { get; set; } = totalPages;
    public bool HasPrevious { get; set; } = hasPrevious;
    public bool HasNext { get; set; } = hasNext;
}