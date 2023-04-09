using CATHODE.Scripting;
using ST.Library.UI.NodeEditor;

namespace CommandsEditor.Nodes
{
	[STNode("/")]
	public class ColourCorrectionTransition : STNode
	{
		private string _m_colour_lut_a;
		[STNodeProperty("colour_lut_a", "colour_lut_a")]
		public string m_colour_lut_a
		{
			get { return _m_colour_lut_a; }
			set { _m_colour_lut_a = value; this.Invalidate(); }
		}
		
		private string _m_colour_lut_b;
		[STNodeProperty("colour_lut_b", "colour_lut_b")]
		public string m_colour_lut_b
		{
			get { return _m_colour_lut_b; }
			set { _m_colour_lut_b = value; this.Invalidate(); }
		}
		
		private float _m_lut_a_contribution;
		[STNodeProperty("lut_a_contribution", "lut_a_contribution")]
		public float m_lut_a_contribution
		{
			get { return _m_lut_a_contribution; }
			set { _m_lut_a_contribution = value; this.Invalidate(); }
		}
		
		private float _m_lut_b_contribution;
		[STNodeProperty("lut_b_contribution", "lut_b_contribution")]
		public float m_lut_b_contribution
		{
			get { return _m_lut_b_contribution; }
			set { _m_lut_b_contribution = value; this.Invalidate(); }
		}
		
		private bool _m_start_on_reset;
		[STNodeProperty("start_on_reset", "start_on_reset")]
		public bool m_start_on_reset
		{
			get { return _m_start_on_reset; }
			set { _m_start_on_reset = value; this.Invalidate(); }
		}
		
		private bool _m_pause_on_reset;
		[STNodeProperty("pause_on_reset", "pause_on_reset")]
		public bool m_pause_on_reset
		{
			get { return _m_pause_on_reset; }
			set { _m_pause_on_reset = value; this.Invalidate(); }
		}
		
		private bool _m_delete_me;
		[STNodeProperty("delete_me", "delete_me")]
		public bool m_delete_me
		{
			get { return _m_delete_me; }
			set { _m_delete_me = value; this.Invalidate(); }
		}
		
		private string _m_name;
		[STNodeProperty("name", "name")]
		public string m_name
		{
			get { return _m_name; }
			set { _m_name = value; this.Invalidate(); }
		}
		
		protected override void OnCreate()
		{
			base.OnCreate();
			
			this.Title = "ColourCorrectionTransition";
			
			this.InputOptions.Add("interpolate", typeof(float), false);
			this.InputOptions.Add("start", typeof(void), false);
			this.InputOptions.Add("stop", typeof(void), false);
			this.InputOptions.Add("pause", typeof(void), false);
			this.InputOptions.Add("resume", typeof(void), false);
			
			this.OutputOptions.Add("started", typeof(void), false);
			this.OutputOptions.Add("stopped", typeof(void), false);
			this.OutputOptions.Add("paused", typeof(void), false);
			this.OutputOptions.Add("resumed", typeof(void), false);
		}
	}
}
