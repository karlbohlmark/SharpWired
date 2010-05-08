using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WiredControls.ToolStripItems
{
	/// <summary>
	/// An item in the animated loading menu strip.
	/// </summary>
	public class AnimatedLoaderItem: ToolStripMenuItem
	{
		#region Constructors
		/// <summary>
		/// Creates an item with the given text as Text.
		/// </summary>
		/// <param name="text">The text.</param>
		public AnimatedLoaderItem(string text):this()
		{
			this.Text = text;
		}

		/// <summary>
		/// Inits components and LoadImages.
		/// </summary>
		public AnimatedLoaderItem()
		{
			InitializeComponent();
			LoadImages();
		}
		#endregion


		#region Properties
		private volatile int mImageIndex;
		/// <summary>
		/// Get/Set the current image index used.
		/// </summary>
		public new int ImageIndex
		{
			get { return mImageIndex; }
			set
			{
				if (mImageIndex != value)
				{
					mImageIndex = value;
					mImageIndex %= images.Length;
					SetImage();
				}
			}
		}
		#endregion


		#region Fields
		private Timer imageChangeTimer;
		private System.ComponentModel.IContainer components;

		Bitmap[] images = new Bitmap[4];
		#endregion


		#region Private Methods
		
		/// <summary>
		/// Loads the images to use in the animation from resources.
		/// </summary>
		private void LoadImages()
		{
			images[0] = AnimatedLoaderItemResources._1_3;
			images[1] = AnimatedLoaderItemResources._3_6;
			images[2] = AnimatedLoaderItemResources._6_9;
			images[3] = AnimatedLoaderItemResources._9_12;
		}
		
		/// <summary>
		/// Sets the controls Image property with the image specified by ImageIndex.
		/// </summary>
		private void SetImage()
		{
			this.Image = images[mImageIndex];
		}

		/// <summary>
		/// You know the drill.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.imageChangeTimer = new System.Windows.Forms.Timer(this.components);
			// 
			// imageChangeTimer
			// 
			this.imageChangeTimer.Tick += new System.EventHandler(this.imageChangeTimer_Tick);

		}

		/// <summary>
		/// When the animation timer ticks, this is what we do. We increase ImageIndex by one.
		/// </summary>
		/// <param name="sender">.</param>
		/// <param name="e">Empty I guess.</param>
		private void imageChangeTimer_Tick(object sender, EventArgs e)
		{
			ImageIndex += 1;
		}
		#endregion


		#region Public Methods
		/// <summary>
		/// Starts the controls animation.
		/// </summary>
		public void Start()
		{
			ImageIndex = 0;
			imageChangeTimer.Start();
		}

		/// <summary>
		/// Stop the animation timer.
		/// </summary>
		public void Stop()
		{
			imageChangeTimer.Stop();
			Image = null;
		}
		#endregion
	}
}