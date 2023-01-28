﻿namespace TalentManagementAPI.Application.Parameters
{
    public class PagingParameter
    {
        private const int maxPageSize = 200;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}