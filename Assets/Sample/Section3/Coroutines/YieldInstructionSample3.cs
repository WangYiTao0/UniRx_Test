using System;
using System.Collections;
using System.IO;
using UniRx;
using UnityEngine;

namespace Sample.Section3.Coroutines
{
    public class YieldInstructionSample3 : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(ReadFileCoroutine());
        }
        // 异步读取FILE
        private IEnumerator ReadFileCoroutine()
        {
            //  Observable 进行 YieldInstruction 变换
            // throwOnError 为 false 时
            // 它将保存失败时的异常。
            // (如果为真，就会按原样抛出异常)
            var yi = ReadFileAsync(@"data.txt")
                .ToYieldInstruction(throwOnError: false);
            // 等待
            yield return yi;
            if (yi.HasError) // HasError 是否出错
            {
                // 失败时 保存异常信息
                Debug.LogError(yi.Error);
            }
            else
            {
                // 成功是输出 Result
                Debug.Log(yi.Result);
            }
 
        }
        // 生成 异步读取FIle 的IObservable
        private IObservable<string> ReadFileAsync(string path)
        {
            return Observable.Start(() =>
            {
                using (var r = new StreamReader(path))
                {
                    return r.ReadToEnd();
                }
            }, Scheduler.ThreadPool);
        }
    }
}