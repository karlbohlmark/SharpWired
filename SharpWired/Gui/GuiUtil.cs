using System;
using System.Globalization;

namespace SharpWired.Gui {
    /// <summary>Util class for GUI</summary>
    public static class GuiUtil {
        /// <summary>Request or set the file destination for the CSS-file</summary>
        public static string CSSFilePath {
            //TODO: The destination to the CSS-file should be set in some other way
            get { return Environment.CurrentDirectory; }
        }

        public static string FormatByte(long bytes) {
            return FormatByte(bytes, "h");
        }

        public static string FormatByte(long bytes, string format) {
            //TODO: Make format global for whole application?
            var nfi = new CultureInfo("en-US").NumberFormat;

            switch (format) {
                case "h":
                    return FormatByte(bytes, HumanReadableByteFormat(bytes));
                case "GiB":
                    return String.Format(nfi, "{0:0.#} GiB", bytes/(double) (1024*1024*1024));
                case "MiB":
                    return String.Format(nfi, "{0:0.#} MiB", bytes/(double) (1024*1024));
                case "KiB":
                    return String.Format(nfi, "{0:0} KiB", bytes/(double) 1024);
                case "B":
                    return String.Format(nfi, "{0:0} B", bytes);
            }
            throw new FormatException("Unable to format bytes '" + bytes +
                                      "' according to format '" + format + "'");
        }

        private static string HumanReadableByteFormat(long bytes) {
            if (bytes >= 1024*1024*1024) {
                return "GiB";
            } else if (bytes >= 1024*1024) {
                return "MiB";
            } else if (bytes >= 1024) {
                return "KiB";
            }

            return "B";
        }

        public static string FormatTimeSpan(TimeSpan time) {
            if (time.Days > 0) {
                return time.Days + " days";
            } else if (time.Hours > 0) {
                return time.Hours + " hours";
            } else if (time.Minutes > 0) {
                return time.Minutes + " minutes";
            } else {
                return time.Seconds + " seconds";
            }
        }
    }
}