﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Scene
    {

        /// <summary>
        /// how many times should this engine run?
        /// <para>0 means endless.</para>
        /// </summary>
        private int maxCycle = 0;
        private int currentCycle;
        private bool running = false;

        /// <summary>
        /// whether this scene's objects are being updated now.
        /// </summary>
        public bool Running
        {
            get { return running; }
            set
            {
                if (value)
                { this.Start(); }
                else
                { this.Stop(); }
            }
        }
        private const double interval = 1000 / 25;
        System.Timers.Timer timer;// = new System.Timers.Timer(10000);   //实例化Timer类，设置间隔时间为10000毫秒；   

        /// <summary>
        /// start running.
        /// </summary>
        /// <param name="maxCycle">
        /// how many times should this engine run?
        /// <para>0 means endless.</para></param>
        public void Start(int maxCycle = 0)
        {
            if (this.running) { return; }

            if (timer == null)
            {
                timer = new System.Timers.Timer(interval);   //实例化Timer类，设置间隔时间为10000毫秒；   
                timer.Elapsed += new System.Timers.ElapsedEventHandler(Tick); //到达时间的时候执行事件；   
                timer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            }

            this.currentCycle = 0;
            this.maxCycle = maxCycle;
            timer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
            this.running = true;
        }

        /// <summary>
        /// stop running.
        /// </summary>
        public void Stop()
        {
            if (!this.running) { return; }

            if (timer != null)
            {
                timer.Enabled = false;     //是否执行System.Timers.Timer.Elapsed事件；   
            }

            this.running = false;
        }

        private void Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.maxCycle <= 0// endless
                || this.currentCycle < this.maxCycle)// not reached last cycle yet
            {
                this.currentCycle++;
                SceneRootObject rootObj = this.rootObject;
                UpdateObject(rootObj, interval);
            }
            else
            {
                this.Stop();
            }
        }

        private void UpdateObject(SceneObject sceneObject, double interval)
        {
            sceneObject.Update(interval);
            SceneObject[] array = sceneObject.Children.ToArray();
            foreach (var child in array)
            {
                UpdateObject(child, interval);
            }
        }

        /// <summary>
        /// update once.
        /// </summary>
        public void Update()
        {
            this.UpdateObject(this.RootObject, 0);
        }
    }
}
