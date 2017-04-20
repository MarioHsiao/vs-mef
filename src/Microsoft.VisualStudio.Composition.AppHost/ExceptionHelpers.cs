﻿// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.VisualStudio.Composition.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class ExceptionHelpers
    {
        internal static string GetUserMessage(this Exception exception)
        {
            Requires.NotNull(exception, nameof(exception));

            var builder = new StringBuilder();
            while (exception != null)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }

                builder.Append(exception.Message);
                if (builder.Length > 0 && builder[builder.Length - 1] != '.')
                {
                    builder.Append(".");
                }

                exception = exception.InnerException;
            }

            return builder.ToString();
        }
    }
}