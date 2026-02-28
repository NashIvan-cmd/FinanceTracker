namespace FinanceTracker.Infrastructure.Models
{
    using System;

    public class PaginationMetadata
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public long TotalItems { get; set; }

        public int TotalPages { get; set; }

        public bool HasNextPage { get; set; }

        public bool HasPreviousPage { get; set; }

        public static PaginationMetadata Create(int pageSize, int offset, long totalItems)
        {
            // Calculate current page from offset and page size
            var currentPage = offset == 0 ? 1 : (offset / pageSize) + 1;
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            return new PaginationMetadata
            {
                Page = currentPage,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                HasNextPage = currentPage < totalPages,
                HasPreviousPage = currentPage > 1,
            };
        }
    }
}