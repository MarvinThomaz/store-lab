namespace Store.Common.Paging
{
    public class PagingParameters
    {
        private int _page;
        private int _recordsPerPage;

        public int Page 
        { 
            get 
            {
                if (_page == 0)
                {
                    return 1;
                }

                return _page;
            } 

            set => _page = value;
        }

        public int RecordsPerPage
        {
            get
            {
                if (_recordsPerPage == 0)
                {
                    _recordsPerPage = 10;
                }

                if (_recordsPerPage > 200)
                {
                    _recordsPerPage = 200;
                }

                return _recordsPerPage;
            }

            set => _recordsPerPage = value;
        }
    }
}
