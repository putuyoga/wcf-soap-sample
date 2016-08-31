# wcf-soap-sample
Simple sample to demonstrate SOAP web service using WCF.

## How to run
First, open the `mySOAP.sln` with your Visual Studio, and then make sure the `mySOAP` project as startup project. 

![Imgur](http://i.imgur.com/19kE4rb.jpg)

after that, we will start our service without debugging by click menu `Debug > Start Without Debugging`

![Imgur](http://i.imgur.com/EPALw5Y.jpg)

You should make sure your service run by open it via browser.

![Imgur](http://i.imgur.com/UTbkoWA.jpg)

then it will be same with step 2, you should make `mySOAP.App` as startup project. 
Next, configure service by right click `configure service reference`. Make sure the URL path is correct.

![Imgur](http://i.imgur.com/DlmKPGb.jpg)

Finally, run the `mySOAP.App` console application.

![Imgur](http://i.imgur.com/VC9NgFQ.jpg)

## Alternative
You can also run the Unit Test via Test Explorer inside Visual Studio.
