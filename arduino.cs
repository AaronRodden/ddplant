using Godot;
using System;
using System.IO.Ports;

public partial class arduino : Node2D
{
	
	SerialPort serialPort;
	RichTextLabel text;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		text = GetNode<RichTextLabel>("RichTextLabel");
		serialPort = new SerialPort();
		serialPort.PortName = "COM3";
		serialPort.BaudRate = 9600;
		serialPort.Open();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!serialPort.IsOpen) return;
		
		string serialMessage = serialPort.ReadExisting();
		
		text.Text = serialMessage;
		
		//if(serialMessage == "a"){
			//text.Text += "Hello Arduino, I hear you :)";
		//}
	}
}
