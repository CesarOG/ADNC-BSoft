using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BSoft.Invoices.Models;
using BSoft.Invoices.Models.Beans;
using Dapper;
using Npgsql;

namespace BSoft.Invoices.DataAccess.Repositories
{
    public class InvoiceRepository : Repository<tbl_invoice>, IInvoiceRepository
    {
        public InvoiceRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<InvoiceBean> ListInvoicesByCustomer(int customerId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("in_customer", customerId);

                connection.BeginTransaction();

                var resultado = connection.Query<InvoiceBean>("fn_list_invoices", parameters, commandType: CommandType.StoredProcedure);

                connection.Close();

                return resultado;
            }
        }

        public IEnumerable<string> PayInvoice(int invoiceId, int serviceId, int customerId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("in_invoice", invoiceId);
                parameters.Add("in_service", serviceId);
                parameters.Add("in_customer", customerId);

                var value = connection.Query<string>("fn_pay_debts", parameters, commandType: CommandType.StoredProcedure);

                connection.BeginTransaction().Commit();
                connection.Close();
                return value;


            }
        }

        public IEnumerable<string> ReverseInvoice(int invoiceId, int serviceId, int customerId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("in_invoice", invoiceId);
                parameters.Add("in_service", serviceId);
                parameters.Add("in_customer", customerId);

                var value = connection.Query<string>("fn_reverse_debts", parameters, commandType: CommandType.StoredProcedure);

                connection.BeginTransaction().Commit();
                connection.Close();
                return value;


            }
        }
    }
}
