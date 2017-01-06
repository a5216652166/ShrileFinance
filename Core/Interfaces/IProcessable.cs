namespace Core.Interfaces
{
    using System;

    public interface IProcessable
    {
        Guid Id { get; set; }

        bool Hidden { get; set; }
    }
}
