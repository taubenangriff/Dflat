namespace Dflat.Core
{
    //Just an interface so I keep everything clean.
    internal interface IBuilder<TResult, TBuilder>
    {
        static IBuilder<TResult, TBuilder> Create(TResult fromResult) => throw new NotImplementedException();
        static IBuilder<TResult, TBuilder> Create() => throw new NotImplementedException();

        TResult Build();

        TBuilder DeepClone();
    }
}
