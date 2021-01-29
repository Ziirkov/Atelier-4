using Invoicing.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace Invoicing.Server.Models
{
    public class BusinessDataSql : IBusinessData, IDisposable
    {
        private SqlConnection cnct;
        public BusinessDataSql(string connectionString)
        {
            cnct = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            cnct.Dispose();
        }
        public IEnumerable<Invoice> AllInvoices => cnct.Query<Invoice>("SELECT Client AS Customer, Numero AS Reference, Datereglement AS Created, MontantDu AS Amount, MontantRegle AS Paid FROM Factures ORDER BY DateReglement DESC"); //On récupère la liste des factures

        public decimal SalesRevenue => cnct.QuerySingle<decimal>("SELECT SUM(MontantRegle) FROM Factures"); //On récupère ici le chiffe d'affaire 

        public decimal Outstanding => cnct.QuerySingle<decimal>("SELECT SUM(MontantDu+MontantRegle) FROM Factures"); //On récupère le Chiffre d'affaire prévisionnel

       // public Invoice s = new Invoice();

    }
}
