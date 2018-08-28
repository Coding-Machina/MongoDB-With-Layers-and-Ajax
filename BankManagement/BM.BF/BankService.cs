using BM.EF;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.BF
{
    public class BankService
    {

        private BankContext ctx = new BankContext();

        public IQueryable<Bank> Get()
        {
            return ctx.Bank.AsQueryable();
        }

        public Bank Post(Bank bnk)
        {
            ctx.Bank.InsertOne(bnk);
            return bnk;
        }

        public Transaction TransInsert(string id, Transaction transaction1)
        {
            if(transaction1.Operation == "deposit")
            {
               var modification = Builders<Bank>
                .Update.Push(r => r.transaction, transaction1)
                .Inc("Balance", transaction1.Amount);

                ctx.Bank.UpdateOne(p => p.Id == id, modification);
                return transaction1;
            }
            else if(transaction1.Operation == "withdraw")
            {
                var curBal = ctx.Bank.Find(p => p.Id == id).SingleOrDefault();
                int Bal = curBal.Balance- transaction1.Amount;
                var modification = Builders<Bank>
                .Update.Push(r => r.transaction, transaction1)
                .Set("Balance", Bal);

                ctx.Bank.UpdateOne(p => p.Id == id, modification);
                return transaction1;
            }
            return transaction1;
        }

        public IQueryable<Transaction> TransGet(string id)
        {
            return ctx.Bank.Find(p => p.Id == id).
                SingleOrDefault().transaction.AsQueryable();
        }
    }
}
