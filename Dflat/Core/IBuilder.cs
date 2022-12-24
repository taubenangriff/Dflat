namespace Dflat.Core
{
    //Just an interface so I keep everything clean.
    public interface IBuilder<TResult, TBuilder> : IBuilder<TResult>
    {
        static IBuilder<TResult, TBuilder> Create(TResult fromResult) => throw new NotImplementedException();
        static IBuilder<TResult, TBuilder> Create() => throw new NotImplementedException();

        TBuilder DeepClone();
    }

    public interface IBuilder<TResult>
    {
        TResult Build();
    }
}
