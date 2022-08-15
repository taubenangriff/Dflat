namespace Dflat.Construction
{
    //Just an interface so I keep everything clean.
    internal interface IBuilder<TResult>
    {
        static IBuilder<TResult> Create(TResult fromResult) => throw new NotImplementedException();
        static IBuilder<TResult> Create() => throw new NotImplementedException();

        TResult GetResult();
    }
}
