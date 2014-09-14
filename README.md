PushbulletSharp
===============

This is a simple pushbullet wrapper written in C#. You can easily add this library to your project via Nuget (https://www.nuget.org/packages/PushBulletSharp/).

There are examples of how to use the library in the test project included. Remember to provide your api key when running the tests.

#### Pushing a Note Example

	PushbulletClient client = new PushbulletClient("--YOURAPIKEY--");
	
	//If you don't know your device_iden, you can always query your devices
	var devices = client.CurrentUsersDevices();
	
	var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();
	
	if (device != null)
	{
    	PushNoteRequest reqeust = new PushNoteRequest()
	    {
    	    device_iden = device.iden,
    	    title = "hello world",
    	    body = "This is a test from my C# wrapper."
    	};
	
    	PushResponse response = client.PushNote(reqeust);
	}