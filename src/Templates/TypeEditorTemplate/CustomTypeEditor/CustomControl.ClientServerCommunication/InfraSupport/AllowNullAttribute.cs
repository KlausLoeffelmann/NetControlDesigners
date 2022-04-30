// This is a helper class, so we can use the AllowNullAttribute on Framework.
// Since the Client-Server is multi-targeted, and Framework doesn't provide
// this class, we define it here, and the compiler picks it up just fine.
#if NETFRAMEWORK
namespace System.Diagnostics.CodeAnalysis
{
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Parameter | System.AttributeTargets.Property, Inherited = false)]
    public class AllowNullAttribute : Attribute
    { }

}
#endif
