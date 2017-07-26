//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Apps.Models;
using Apps.Common;
using Microsoft.Practices.Unity;
using System.Transactions;
using Apps.BLL.Core;
using Apps.Locale;
using Apps.DEF.IDAL;
using Apps.Models.DEF;
namespace Apps.DEF.BLL
{
	public class Virtual_DEF_TestCaseStepsBLL
	{
        [Dependency]
        public IDEF_TestCaseStepsRepository m_Rep { get; set; }

		public virtual List<DEF_TestCaseStepsModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<DEF_TestCaseSteps> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								a=>a.ItemID.Contains(queryStr)
								|| a.Code.Contains(queryStr)
								|| a.Title.Contains(queryStr)
								|| a.TestContent.Contains(queryStr)
								
								
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            pager.totalRows = queryData.Count();
            //排序
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        public virtual List<DEF_TestCaseStepsModel> CreateModelList(ref IQueryable<DEF_TestCaseSteps> queryData)
        {

            List<DEF_TestCaseStepsModel> modelList = (from r in queryData
                                              select new DEF_TestCaseStepsModel
                                              {
													ItemID = r.ItemID,
													Code = r.Code,
													Title = r.Title,
													TestContent = r.TestContent,
													state = r.state,
													sort = r.sort,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(ref ValidationErrors errors, DEF_TestCaseStepsModel model)
        {
            try
            {
			    DEF_TestCaseSteps entity = m_Rep.GetById(model.ItemID);
                if (entity != null)
                {
                    errors.Add(Resource.PrimaryRepeat);
                    return false;
                }
                entity = new DEF_TestCaseSteps(); 
				entity.ItemID = model.ItemID;
				entity.Code = model.Code;
				entity.Title = model.Title;
				entity.TestContent = model.TestContent;
				entity.state = model.state;
				entity.sort = model.sort;
  

                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Resource.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }



         public virtual bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public virtual bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        if (m_Rep.Delete(deleteCollection) == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

		
       

        public virtual bool Edit(ref ValidationErrors errors, DEF_TestCaseStepsModel model)
        {
            try
            {
                DEF_TestCaseSteps entity = m_Rep.GetById(model.ItemID);
                if (entity == null)
                {
                    errors.Add(Resource.Disable);
                    return false;
                }
                              				entity.ItemID = model.ItemID;
				entity.Code = model.Code;
				entity.Title = model.Title;
				entity.TestContent = model.TestContent;
				entity.state = model.state;
				entity.sort = model.sort;
 


                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Resource.NoDataChange);
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

      

        public virtual DEF_TestCaseStepsModel GetById(string id)
        {
            if (IsExists(id))
            {
                DEF_TestCaseSteps entity = m_Rep.GetById(id);
                DEF_TestCaseStepsModel model = new DEF_TestCaseStepsModel();
                              				model.ItemID = entity.ItemID;
				model.Code = entity.Code;
				model.Title = entity.Title;
				model.TestContent = entity.TestContent;
				model.state = entity.state;
				model.sort = entity.sort;
 
                return model;
            }
            else
            {
                return null;
            }
        }

        public virtual bool IsExists(string id)
        {
            return m_Rep.IsExist(id);
        }
		  public void Dispose()
        { 
            
        }

	}
}