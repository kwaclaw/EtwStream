﻿using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace EtwStream
{
    public static partial class EtwStreamObservableExtensions
    {
        public static IObservable<T> TakeUntil<T>(this IObservable<T> source, CancellationToken terminateToken)
        {
            var subject = new Subject<Unit>();

            terminateToken.Register(s =>
            {
                var ss = s as Subject<Unit>;
                ss.OnNext(Unit.Default);
                ss.OnCompleted();
            }, subject);

            return source.TakeUntil(subject);
        }

        public static IObservable<IList<T>> Buffer<T>(this IObservable<T> source, TimeSpan timeSpan, int count, CancellationToken terminateToken)
        {
            return source.TakeUntil(terminateToken).Buffer(timeSpan, count);
        }
    }
}