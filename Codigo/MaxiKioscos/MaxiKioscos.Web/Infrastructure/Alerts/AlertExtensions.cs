using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MaxiKioscos.Web.Infrastructure.Alerts
{
	public static class AlertExtensions
	{
		const string Alerts = "_Alerts";

        public static List<Alert> GetAlerts(this HttpSessionStateBase sessionState)
		{
			if (sessionState[Alerts] == null)
			{
				sessionState[Alerts] = new List<Alert>();
			}

			return (List<Alert>) sessionState[Alerts];
		}

		public static ActionResult WithSuccess(this ActionResult result, string message)
		{
			return new AlertDecoratorResult(result, "alert-success", message);
		}

		public static ActionResult WithInfo(this ActionResult result, string message)
		{
			return new AlertDecoratorResult(result, "alert-info", message);
		}

		public static ActionResult WithWarning(this ActionResult result, string message)
		{
			return new AlertDecoratorResult(result, "alert-warning", message);
		}

		public static ActionResult WithError(this ActionResult result, string message)
		{
			return new AlertDecoratorResult(result, "alert-danger", message);
		}
	}
}