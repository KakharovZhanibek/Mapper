using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper_
{
    internal class PaymentEntity
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentCardNumber { get; set; }
        public decimal PaymentAmount { get; set; }
    }


    internal class PaymentDetailModel
    {
        public DateTime PaymentDate { get; set; }
        public string PaymentCardNumber { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var source = new PaymentEntity()
            {
                Id = Guid.NewGuid(),
                PaymentDate = new DateTime(2017, 12, 11),
                PaymentCardNumber = "0000-0000-0000-0001",
                PaymentAmount = 500
            };

            #region API V1

            var destinationV1 = source.Map<PaymentDetailModel>();
            #endregion

            #region API V2

            var mapper = new Mapper<PaymentEntity, PaymentDetailModel>();
            var destinationV2 = mapper.Map(source);
            #endregion
        }
    }
}
