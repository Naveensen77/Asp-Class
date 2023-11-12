using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CommanddlFill
/// </summary>
public class CommanddlFill
{
    APIProcedure objdb = new APIProcedure();
    DataSet ds;
    public CommanddlFill()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet DivisionFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "0" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet DistrictFill(string Division_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "Division_id", "type" }, new string[] { Division_id, "1" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet PhaseFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "2" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }


    public DataSet AdminOfficeFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "2" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }


    public DataSet ItemCategoryFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "3" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet ItemTypeFill(string ItemCat_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type", "ItemCat_id" }, new string[] { "4", ItemCat_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet ItemMasterFill(string ItemCat_id, string ItemType_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type", "ItemCat_id", "ItemType_id" }, new string[] { "5", ItemCat_id, ItemType_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet UnitFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "6" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet UnitFillByItemId(string Item_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type", "Item_id" }, new string[] { "7", Item_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
     
    public DataSet ProductFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "9" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet ProductSizeFillByProduct_id(string Prod_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type", "Prod_id" }, new string[] { "10", Prod_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet ProductionUnitFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "11" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet VendorFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "12" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet VendorCategoryFill(string Vendor_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type", "Vendor_id" }, new string[] { "13", Vendor_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet VendorTypeFill(string Vendor_id, string ItemCat_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type", "Vendor_id", "ItemCat_id" }, new string[] { "14", Vendor_id, ItemCat_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet VendorItemFill(string Vendor_id, string ItemCat_id, string ItemType_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type", "Vendor_id", "ItemCat_id", "ItemType_id" }, new string[] { "15", Vendor_id, ItemCat_id, ItemType_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet WarehouseFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "16" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet UnitAndRateFillByItemId(string Vendor_id, string Item_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type", "Vendor_id", "Item_id" },
                new string[] { "17", Vendor_id, Item_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet ProductFillByProductionUnit_id(string ProducUnit_id)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "ProducUnit_id", "type" }, new string[] { ProducUnit_id, "18" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet HSNFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "19" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet BankFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "20" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet CustomerFill(string CustType)
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "CustType", "type" }, new string[] { CustType, "21" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet PURatioPerUnitFill()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "22" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }




    // PU CODE

    public DataSet ProductFillByProductionUnit(string Office_ID)
    {
        try
        {
            return objdb.ByProcedure("Proc_tblPuSupplyOrder", new string[] { "flag", "Office_ID" }, new string[] { "8", Office_ID }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }

     
    public DataSet ItemCategoryFillByProductionUnit(string ItemCat_id)
    {
        try
        {
            return objdb.ByProcedure("Proc_FillCategoryByPU", new string[] { "flage", "ItemCat_id" }, new string[] { "1", ItemCat_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }



    public DataSet MBVKFill(string District_id, string Division_id)
    {
        try
        {
            return objdb.ByProcedure("Proc_tblPuSupplyOrder", new string[] { "flag", "District_id", "Division_id" }, new string[] { "12", District_id, Division_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
     
    public DataSet BranchFill(string District_id, string Division_id)
    {
        try
        {
            return objdb.ByProcedure("Proc_tblPuSupplyOrder", new string[] { "flag", "District_ID", "Division_ID" }, new string[] { "9", District_id, Division_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }

    public DataSet CustomerFill()
    {
        try
        {
            return objdb.ByProcedure("Proc_tblPuSupplyOrder", new string[] { "flag"}, new string[] { "10"}, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }

    public DataSet MBVKFillBYID(string MBVK_id)
    {
        try
        {
            return objdb.ByProcedure("Proc_tblPuSupplyOrder", new string[] { "flag", "MBVK_id" }, new string[] { "13", MBVK_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet BranchFillBYID(string Office_ID)
    {
        try
        {
            return objdb.ByProcedure("Proc_tblPuSupplyOrder", new string[] { "flag", "Office_ID" }, new string[] { "14", Office_ID }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }
    public DataSet CustomerFillBYID(string Cust_id)
    {
        try
        {
            return objdb.ByProcedure("Proc_tblPuSupplyOrder", new string[] { "flag", "Cust_id" }, new string[] { "15", Cust_id }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }

    public DataSet GetFY()
    {
        try
        {
            return objdb.ByProcedure("ProcCommTablesFill", new string[] { "type" }, new string[] { "12" }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }

    public DataSet CustomerFillBYID(string Ledger_ID, string Office_ID)
    {
        try
        {
            return objdb.ByProcedure("Proc_tblPuSupplyOrder", new string[] { "flag", "Ledger_ID", "Office_ID" }, new string[] { "1515", Ledger_ID, Office_ID }, "Dataset");
        }
        catch (Exception ex) { throw ex; }
    }

    public DataSet CustomerFill(string Office_ID, string pagename)
    {
        try
        {
            return objdb.ByProcedure("Proc_tblPuSupplyOrder", new string[] { "flag", "Office_ID" }, new string[] { "1010", Office_ID }, "Dataset");

        }
        catch (Exception ex) { throw ex; }
    }
}