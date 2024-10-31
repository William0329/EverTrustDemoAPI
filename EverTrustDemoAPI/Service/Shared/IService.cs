using System.Linq.Expressions;

namespace EverTrustDemoAPI.Service.Shared
{
    public interface IService<T>
    {
        /// <summary>
        /// 取得 IEnumerable 資料
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetListAsync();
        public Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 取單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetAsync(string id);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 創資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns> id </returns>
        public Task<string> CreateAsync(T data);
        /// <summary>
        /// 更新資料(單筆)
        /// </summary>
        /// <param name="updatedData"></param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(T updatedData);
        /// <summary>
        /// 更新資料(多筆)
        /// </summary>
        /// <param name="updatedDatas"></param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(IEnumerable<T> updatedDatas);
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(string id);
        /// <summary>
        /// 刪除資料(多筆)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(IEnumerable<string> ids);
    }
}
