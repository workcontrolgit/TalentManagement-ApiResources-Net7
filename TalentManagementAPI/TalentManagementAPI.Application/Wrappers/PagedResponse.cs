using TalentManagementAPI.Application.Parameters;

namespace TalentManagementAPI.Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public virtual int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }



        /// <summary>
        /// Constructor for PagedResponse class.
        /// </summary>
        /// <param name="data">Data to be returned.</param>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="recordsCount">Records count.</param>
        /// <returns>
        /// An instance of PagedResponse.
        /// </returns>
        public PagedResponse(T data, int pageNumber, int pageSize, RecordsCount recordsCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.RecordsFiltered = recordsCount.RecordsFiltered;
            this.RecordsTotal = recordsCount.RecordsTotal;
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}