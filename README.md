# RemoteProcessFunctionCall

This project only work with 32bits for now
Maybe some bugs could happens because i did a directly byte / assembly translation

This is an example app but you can use directly the class RemoteMethod in your projects

# Remote Method Docs

First you need to instance the class with the target process Id

        RemoteMethod aRemoteMethod = new RemotheMethod(pid);

Now you need to allocate the memory to write the call to the function
This only need to be done on the first time for the call

        object[] r = aRemoteMethod.allocateCall();
        if (!(bool)r[0])
        {
            MessageBox.Show((string)r[1], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

the object[] returned contains on index 0 a boolean with the status true or false
and at index 1 the error/success message

To set the function address:

        aRemoteMethod.functionAddr = (IntPtr)0x0C30D020;

The params for the function can be only numbers (it includes boolean because is 1 or 0)

        aRemoteMethod.paramList.Add(100);

You can set some register before the call with:

        aRemoteMethod.registerEAX = 0x20202020;
        aRemoteMethod.writeEAX = true;

And finally call the function with

        r = aRemoteMethod.Call();
        if (!(bool)r[0])
        {
            MessageBox.Show((string)r[1], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        else
        {
            MessageBox.Show((string)r[1], "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

Warning:

    clearCall method are not implemented in the lastest version!


# END
