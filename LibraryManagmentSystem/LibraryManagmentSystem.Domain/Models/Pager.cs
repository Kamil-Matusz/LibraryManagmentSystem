using System;
namespace LibraryManagmentSystem.Domain.Models
{
    public class Pager
    {
        private int pageIndex;
        private int pageSize;
        private int totalRows;

        public virtual int PageIndex
        {
            get
            {
                if (pageIndex < TotalPages)
                {
                    return pageIndex;
                }
                else if (TotalPages > 0)
                {
                    return TotalPages;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                pageIndex = value > 0 ? value : 1;
            }
        }

        public virtual int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > 0 ? value : 1;
            }
        }

        public virtual int TotalRows
        {
            get
            {
                return totalRows;
            }
            set
            {
                totalRows = value > 0 ? value : 0;
            }
        }

        public virtual int TotalPages
        {
            get
            {
                if (PageSize > 0)
                    return Convert.ToInt32(Math.Ceiling((double)TotalRows / PageSize));
                else
                    return 0;
            }
        }

        public virtual int Offset
        {
            get
            {
                return (PageIndex - 1) * PageSize;
            }
        }

        public Pager() : this(1, 20)
        {
        }

        public Pager(Pager pager)
        {
            totalRows = pager.totalRows;
            pageIndex = pager.pageIndex;
            pageSize = pager.pageSize;
        }

        public Pager(int pageIndex, int pageSize = 20)
        {
            TotalRows = Int32.MaxValue;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

    public static partial class PagerExtensions
    {
        public static IQueryable<TModel> Paginate<TModel>(this IQueryable<TModel> query, Pager pager) where TModel : class
        {
            // Count
            pager.TotalRows = query.Count();

            // Pager
            query = query
                .Skip<TModel>(pager.Offset)
                .Take<TModel>(pager.PageSize);

            return query;
        }
    }
}

