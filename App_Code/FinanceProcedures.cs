using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// All comman function and datalist from sql
/// </summary>
public class FinanceProcedures
{
    APIProcedure obj = new APIProcedure();
    CultureInfo cult = new CultureInfo("en-US", true);
   
    public FinanceProcedures()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //To get financial year with current date
    public string FinanceYear(string VoucherTx_Date)
    {
        try
        {
            string sDate = (Convert.ToDateTime(VoucherTx_Date, cult).ToString("yyyy/MM/dd")).ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            int Month = int.Parse(datevalue.Month.ToString());
            int Year = int.Parse(datevalue.Year.ToString());
            int FY = Year;
            string FinancialYear = Year.ToString();
            string LFY = FinancialYear.Substring(FinancialYear.Length - 2);
            FinancialYear = "";

            if (Month <= 3)
            {
                FY = Year - 1;
                FinancialYear = FY.ToString() + "-" + LFY.ToString();

            }
            else
            {

                FinancialYear = FY.ToString() + "-" + (int.Parse(LFY) + 1).ToString();
            }
            return FinancialYear;
        }
        catch (Exception ex)
        {
            ErrorLogCls.SendErrorToText(ex);
            return null;
        }

    }
    //Get voucher date from database
    public DataTable VoucherDate(string Office_ID)
    {
        try
        {
            return obj.ByProcedure("SpFinVoucherDate", new string[] { "flag", "Office_ID" }, new string[] { "2", Office_ID }, "DataTable", "");
        }
        catch (Exception ex)
        {
            ErrorLogCls.SendErrorToText(ex);
            return null;
        }
    }
    //get list of all ledgers mapped with particular office and mapped with voucher to group 
    public DataTable VoucherLedgerList(string Office_ID, string Voucher_ID)
    {
        try
        {
            return obj.ByProcedure("Finance.Usp_GetVoucherWiseLedger", new string[] { "Office_ID", "Voucher_ID" },
                new string[] { Office_ID, Voucher_ID }, "DataTable", "");
        }
        catch (Exception ex)
        {
            ErrorLogCls.SendErrorToText(ex);
            return null;
        }
    }
    //get series number of last generated voucher
    public DataSet PreviousVoucher(string Office_ID, string VoucherTx_FY, string Voucher_ID)
    {
        try
        {
            return obj.ByProcedure("Finance.Usp_GetPreviousVoucher", new string[] { "Office_ID", "VoucherTx_FY", "Voucher_Id" }, new string[] { Office_ID, VoucherTx_FY, Voucher_ID }, "DataSet");
        }
        catch (Exception ex)
        {
            ErrorLogCls.SendErrorToText(ex);
            return null;
        }
    }
    //get valid date against office id and financial year from current date
    public DataTable VoucherValidDate(string VoucherTx_Date, string Office_ID, string FinancialYear)
    {
        try
        {
            return obj.ByProcedure("SpFinEditRight", new string[] { "flag", "Office_ID", "VoucherDate", "FinancialYear" },
            new string[] { "3", Office_ID, Convert.ToDateTime(VoucherTx_Date, cult).ToString("yyyy/MM/dd"), FinancialYear }, "DataTable", "");
        }
        catch (Exception ex)
        {
            ErrorLogCls.SendErrorToText(ex);
            return null;
        }
    }

    public DataTable AllActiveOffie()
    {
        try
        {
            return obj.ByProcedure("Finance.Uspfin_GetAllOfficeList", new string[] { }, new string[] { }, "DataTable", "");
        }
        catch (Exception ex)
        {
            ErrorLogCls.SendErrorToText(ex);
            return null;
        }
    }

    //  by pawan on 16-06-2023 variable for check according to use
    public string GetTypeOfSupplyGoods() { return "Goods"; }
    public string GetTypeOfSupplyServices() { return "Services"; }
    public string GetDefaultBankAccountDetails() { return "BANK ACCOUNT DETAILS"; }
    public string GetDefaultTaxRegistrationDetails() { return "TAX REGISTRATION DETAILS"; }
    public string SqlUniquekeyErrorCode() { return "-2146232060"; }
    // end by pawan on 16-06-2023

    //By Raghav 09-08-2023 start
    public DataTable GetTaxability()
    {
        try
        {
            return obj.ByProcedure("Finance.Usp_Mst_Taxability_Get", new string[] { }, new string[] { }, "DataTable", "");
        }
        catch (Exception ex)
        {
            ErrorLogCls.SendErrorToText(ex);
            return null;
        }
    }
    public DataTable GetIntegratedTax(string Taxability)
    {
        try
        {
            return obj.ByProcedure("Finance.Usp_Mst_IntegratedTax_Get", new string[] { "Taxability" }, new string[] {Taxability}, "DataTable", "");
        }
        catch (Exception ex)
        {
            ErrorLogCls.SendErrorToText(ex);
            return null;
        }
    }
    //By Raghav 09-08-2023 end

    public DataTable CreateLedgerTable()
    {
        
        DataTable dtVoucherLedger = new DataTable();
        DataColumn RowNo = dtVoucherLedger.Columns.Add("RowNo", typeof(int));
        dtVoucherLedger.Columns.Add(new DataColumn("Ledger_ID", typeof(string)));
        dtVoucherLedger.Columns.Add(new DataColumn("Ledger_Name", typeof(string)));
        dtVoucherLedger.Columns.Add(new DataColumn("Type", typeof(string)));
        dtVoucherLedger.Columns.Add(new DataColumn("LedgerTx_MaintainType", typeof(string)));
        dtVoucherLedger.Columns.Add(new DataColumn("LedgerTx_Credit", typeof(decimal)));
        dtVoucherLedger.Columns.Add(new DataColumn("LedgerTx_Debit", typeof(decimal)));

        RowNo.AutoIncrement = true;
        RowNo.AutoIncrementSeed = 1;
        RowNo.AutoIncrementStep = 1;

        return dtVoucherLedger;
    }
}