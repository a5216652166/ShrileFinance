namespace Core.Services.CreditInvestigation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.CreditInvestigation;
    using Entities.CreditInvestigation.Datagram;
    using Entities.CreditInvestigation.DatagramFile;
    using Entities.CreditInvestigation.Record.LoanRecords;
    using Interfaces.Repositories;

    public class DatagramFactory
    {
        private readonly ICreditContractRepository creditRepository;
        private readonly ILoanRepository loanRepository;

        public DatagramFactory(
            ICreditContractRepository creditRepository,
            ILoanRepository loanRepository)
        {
            this.creditRepository = creditRepository;
            this.loanRepository = loanRepository;
        }

        public void Generate(IEnumerable<MessageTrack> traces)
        {
            foreach (var trace in traces)
            {
                switch (trace.OperationType)
                {
                    case MessageOperationTypeEnum.添加机构:
                        break;
                    case MessageOperationTypeEnum.签订授信合同:
                        break;
                    case MessageOperationTypeEnum.借款:
                        break;
                    case MessageOperationTypeEnum.还款:
                        break;
                    case MessageOperationTypeEnum.终止合同:
                        break;
                    case MessageOperationTypeEnum.逾期:
                        break;
                    case MessageOperationTypeEnum.合同变更:
                        break;
                    case MessageOperationTypeEnum.欠息:
                        break;
                    default:
                        break;
                }

                if (trace.MessageStatus == MessageStatusEmum.待生成)
                {
                    trace.MessageStatus = MessageStatusEmum.待发送;
                }
            }
        }

        private LoanDatagramFile CreateLoan(Guid id)
        {
            var loan = loanRepository.Get(id);
            var credit = creditRepository.Get(loan.CreditId);

            var df = new LoanDatagramFile("0001");
            var d = df.Datagrams.Single(m => m.Type == DatagramTypeEnum.信贷业务信息文件);
            var loanRecord = new LoanIousInfoRecord();
            var creditRecord = new LoanContractInfoRecord();

            // Mapper.Map(loan, loanRecord);
            // Mapper.Map(credit, creditRecord);

            // d.Add(loanRecord);
            // d.Add(creditRecord);

            return df;
        }
    }
}
