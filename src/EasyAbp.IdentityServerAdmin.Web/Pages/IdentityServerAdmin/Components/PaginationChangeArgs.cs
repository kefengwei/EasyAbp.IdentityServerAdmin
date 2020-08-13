namespace EasyAbp.IdentityServerAdmin.Web
{
    public class PaginationChangeArgs
    {
        /// <summary>
        /// 每页个数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
    }
}