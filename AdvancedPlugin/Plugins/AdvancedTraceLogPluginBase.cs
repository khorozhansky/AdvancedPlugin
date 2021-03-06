﻿namespace AdvancedPlugin.Plugins
{
  using AdvancedPlugin.Logging;

  using Microsoft.Xrm.Sdk;
  using Microsoft.Xrm.Sdk.Client;

  /// <summary>
  /// A base class for all the Plugin classes inside the project which will use "Advanced Trace Log Engine" (detailed info will be saved in the "Advanced Plugin Trace" custom entity)
  /// </summary>
  /// <typeparam name="TEntity">The type of the entity.</typeparam>
  /// <typeparam name="TContext">A type that inherits from the <see cref="OrganizationServiceContext" /></typeparam>
  /// <remarks>
  /// This definition states that all derived manager classes will use <see cref="AdvancedTraceLog" /> as a "Trace Log Engine"
  /// In such a base class of concrete plugin assembly we should implement <see cref="BuildTraceLog" /> to give the system a way of building "Trace Log"
  /// <seealso cref="AdvancedTraceLog" />
  /// </remarks>
  public abstract class AdvancedTraceLogPluginBase<TEntity, TContext> : PluginBase<TEntity, TContext, AdvancedTraceLog>
    where TEntity : Entity, new()
    where TContext : OrganizationServiceContext
  {
    protected AdvancedTraceLogPluginBase(
      string unsecureConfig,
      string secureConfig) 
      : base(unsecureConfig, secureConfig)
    {
    }

    protected override AdvancedTraceLog BuildTraceLog(IPluginContextBase pluginCtx, ITracingService tracingService)
    {
      return new AdvancedTraceLog(pluginCtx, tracingService);
    }
  }
}
