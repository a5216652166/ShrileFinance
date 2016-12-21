namespace Core.Services.CreditInvestigation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.CreditInvestigation;
    using Entities.CreditInvestigation.Datagram;
    using Entities.CreditInvestigation.DatagramFile;
    using Entities.CreditInvestigation.Record.LoanRecords;
    using Exceptions;
    using Interfaces.Repositories;

    public class DatagramFactoryService
    {
        private readonly ICreditContractRepository creditRepository;
        private readonly ILoanRepository loanRepository;

        public DatagramFactoryService(
            ICreditContractRepository creditRepository,
            ILoanRepository loanRepository)
        {
            this.creditRepository = creditRepository;
            this.loanRepository = loanRepository;
        }

        public void Generate(IEnumerable<Trace> traces)
        {
            AbsDatagramFile datagramFile;

            foreach (var trace in traces)
            {
                switch (trace.Type)
                {
                    case TraceTypeEnum.添加机构:
                        datagramFile = CreateLoan(trace.ReferenceId);
                        break;
                    case TraceTypeEnum.签订授信合同:
                        datagramFile = CreateLoan(trace.ReferenceId);
                        break;
                    case TraceTypeEnum.借款:
                        datagramFile = CreateLoan(trace.ReferenceId);
                        break;
                    case TraceTypeEnum.还款:
                        datagramFile = CreateLoan(trace.ReferenceId);
                        break;
                    case TraceTypeEnum.终止合同:
                        datagramFile = CreateLoan(trace.ReferenceId);
                        break;
                    case TraceTypeEnum.逾期:
                        datagramFile = CreateLoan(trace.ReferenceId);
                        break;
                    case TraceTypeEnum.合同变更:
                        datagramFile = CreateLoan(trace.ReferenceId);
                        break;
                    case TraceTypeEnum.欠息:
                        datagramFile = CreateLoan(trace.ReferenceId);
                        break;
                    default:
                        throw new ArgumentOutOfRangeAppException(nameof(trace.Type), "不支持的跟踪操作类型。");
                }

                trace.AddDatagram(datagramFile);
            }
        }

        /// <summary>
        /// 创建报文文件
        /// </summary>
        /// <param name="fileType">报文文件种类</param>
        /// <returns></returns>
        private AbsDatagramFile CreateFile(DatagramFileType fileType)
        {
            AbsDatagramFile file;
            var serialNumber = GenerateSerialNumber();

            switch (fileType)
            {
                case DatagramFileType.机构基本信息采集报文文件:
                    file = new OrganizationDatagramFile(serialNumber);
                    break;
                case DatagramFileType.信贷业务信息文件:
                    file = new LoanDatagramFile(serialNumber);
                    break;
                default:
                    throw new ArgumentOutOfRangeAppException(nameof(fileType), "无效的报文文件类型。");
            }

            return file;
        }

        /// <summary>
        /// 生成序列号
        /// </summary>
        /// <returns></returns>
        private string GenerateSerialNumber()
        {
            throw new NotImplementedException();
        }

        private AbsDatagramFile CreateLoan(Guid id)
        {
            var loan = loanRepository.Get(id);
            var credit = creditRepository.Get(loan.CreditId);

            var loanRecord = new LoanIousInfoRecord(loan, credit);
            var creditRecord = new LoanContractInfoRecord(credit);

            var file = CreateFile(DatagramFileType.信贷业务信息文件);
            var datagram = file.Datagrams.Single(m => m.Type == DatagramTypeEnum.贷款业务信息采集报文);

            datagram.AddRecord(creditRecord);
            datagram.AddRecord(loanRecord);

            return file;
        }
    }
}
