using TalentManagementAPI.Application.Parameters;

namespace TalentManagementAPI.Application.Wrappers
{
    public class PagedDataTableResponse<T> : Response<T>
    {
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }



        /// <summary>
        /// Constructor for PagedDataTableResponse class.
        /// </summary>
        /// <param name="data">Data to be returned.</param>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="recordsCount">Records count.</param>
        /// <returns>
        /// An instance of PagedDataTableResponse.
        /// </returns>
        public PagedDataTableResponse(T data, int pageNumber, RecordsCount recordsCount)
        {
            this.Draw = pageNumber;
            this.RecordsFiltered = recordsCount.RecordsFiltered;
            this.RecordsTotal = recordsCount.RecordsTotal;
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}