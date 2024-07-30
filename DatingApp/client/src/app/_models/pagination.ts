export interface Pagination {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
  hasPrevious: boolean;
  hasNext: boolean;
}

export class PaginatedResult<T> {
  items?: T;
  pagination?: Pagination;
}