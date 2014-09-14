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

#### Pushing a List Example

	PushbulletClient client = new PushbulletClient("--YOURAPIKEY--");
	
	//If you don't know your device_iden, you can always query your devices
    var devices = Client.CurrentUsersActiveDevices();

    var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();

    if (device != null)
    {
        PushListRequest reqeust = new PushListRequest()
        {
            device_iden = device.iden,
            title = "Shopping List"
        };

        reqeust.items.Add("Milk");
        reqeust.items.Add("Bread");
        reqeust.items.Add("Chicken");

        PushResponse response = Client.PushList(reqeust);
    }

#### Pushing an Address Example

	PushbulletClient client = new PushbulletClient("--YOURAPIKEY--");
	
	//If you don't know your device_iden, you can always query your devices
	var devices = Client.CurrentUsersActiveDevices();

    var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();

    if (device != null)
    {
        PushAddressRequest reqeust = new PushAddressRequest()
        {
            device_iden = device.iden,
            name = "Apple Incorporated",
            address = "1 Infinite Loop, Cupertino, CA 95014"
        };

        PushResponse response = Client.PushAddress(reqeust);
    }

#### Pushing a Link Example

	PushbulletClient client = new PushbulletClient("--YOURAPIKEY--");
	
	//If you don't know your device_iden, you can always query your devices
    var devices = Client.CurrentUsersActiveDevices();

    var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();

    if (device != null)
    {
        PushLinkRequest reqeust = new PushLinkRequest()
        {
            device_iden = device.iden,
            title = "Google",
            url = "http://google.com/",
            body = "Search the internet."
        };

        PushResponse response = Client.PushLink(reqeust);
    }

#### Pushing a File Example

	PushbulletClient client = new PushbulletClient("--YOURAPIKEY--");
	
	//If you don't know your device_iden, you can always query your devices
    var devices = Client.CurrentUsersActiveDevices();

    var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();

    if (device != null)
    {
        PushFileRequest request = new PushFileRequest()
        {
            device_iden = device.iden,
            file_name = "daftpunk.png",
            file_type = "image/png",
            file_path = @"C:\daftpunk.png",
            body = "Work It Harder\r\nMake It Better\r\nDo It Faster"
        };

        var response = Client.PushFile(request);
    }