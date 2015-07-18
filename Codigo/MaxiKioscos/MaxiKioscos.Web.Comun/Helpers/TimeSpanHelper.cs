using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MaxiKioscos.Web.Comun.ActionResults.utilsResult;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MaxiKioscos.Web.Comun.Helpers
{
    public class TimeSpanHelper
    {
        /// <summary>
        /// Tests if two given times overlap each other.
        /// </summary>
        /// <param name="bs">Base period start</param>
        /// <param name="be">Base period end</param>
        /// <param name="ts">Test period start</param>
        /// <param name="te">Test period end</param>
        /// <returns>
        /// 	<c>true</c> if the periods overlap; otherwise, <c>false</c>.
        /// </returns>
        public static bool TimePeriodOverlap(TimeSpan bs, TimeSpan be, TimeSpan ts, TimeSpan te)
        {
            // More simple?
            // return !((TS < BS && TE < BS) || (TS > BE && TE > BE));

            // The version below, without comments 
            /*
            return (
                (TS >= BS && TS < BE) || (TE <= BE && TE > BS) || (TS <= BS && TE >= BE)
            );
            */

            return (
                // 1. Case:
                //
                //       TS-------TE
                //    BS------BE 
                //
                // TS is after BS but before BE
                (ts >= bs && ts < be)
                || // or

                // 2. Case
                //
                //    TS-------TE
                //        BS---------BE
                //
                // TE is before BE but after BS
                (te <= be && te > bs)
                || // or

                // 3. Case
                //
                //  TS----------TE
                //     BS----BE
                //
                // TS is before BS and TE is after BE
                (ts <= bs && te >= be)
            );
        }
    }
}
