

# <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjoXuccUeOPSxWzkgg7Eknvk_8-m4_FEp_Uw&usqp=CAU" alt="drawing" width="50"/> Azure Service Bus


- Azure Service Bus is a fully managed messaging cloud service and different types of applications can communicate with each other via a message queue. Message can transfer between the different applications and it includes metadata about the message and the encoded information in different formats like JSON or XML.

- It allows you to decouple different components of your application by enabling asynchronous communication between them.

- Azure Service bus is a mechanism that allow different components to communicate with each other  without knowing about each other and reduce the thight coupling between the components.

    ![App Screenshot](https://learn.microsoft.com/en-us/azure/includes/media/howto-service-bus-queues/sb-queues-08.png)

    


# 🛠 Integration with Asp.Net Core Applications


<img src="https://damienbod.files.wordpress.com/2019/04/azurebusaspnetcore_01.png" alt="drawing" width="600"/>


### ***Integrating the Azure Service Bus with an ASP.NET Core application involves several steps. I’ll outline the main steps below:***

- **Step 1 : Create an Azure Service Bus Namespace**

   In the Azure portal, create a Service Bus namespace that will serve as the logical container for your messaging entities, such as queues or topics.

- **Step 2 : Obtain the connection string**

   Retrieve the connection string for your Service Bus namespace. This connection string will be used by your ASP.NET Core application to connect to the Service Bus.

- **Step 3 : Install the required NuGet packages**

  In your ASP.NET Core application, install the ```Microsoft.Azure.ServiceBus``` NuGet package. This package provides the necessary libraries for interacting with the Azure Service Bus.

- **Step 4 : Configure the Service Bus connection in your ASP.NET Core application**

    In your application’s configuration file (e.g., `appsettings.json`), add the Service Bus connection string obtained in step. It should look something like this: 
    ```json
    {
        "ConnectionStrings" : {
            "AzureServiceBus" : [AZURE_SERVICE_BUS_CONNECTION_STRING]
        },
        "AzureQueue" : [QUEUE_NAME]
    }
    ```

- **Step 5 : Create a Service Bus client**

   In your ASP.NET Core application, create an instance of the `QueueClient` or `TopicClient` class, depending on whether you want to send messages to a queue or a topic. Pass in the Service Bus connection string from your configuration file.
   
   ![image](https://github.com/jil1710/ASB/assets/125335932/9a26792b-bf8c-456e-becb-775f4d562676)

  

- **Step 6 : Send messages to the Service Bus**

    Use the `SendAsync` method of the `QueueClient` or `TopicClient` to send messages to the Service Bus.
    ![image](https://github.com/jil1710/ASB/assets/125335932/bb580ffe-035c-4115-9485-8534b87c120f)


- **Step 7 : Receive messages from the Service Bus**

    To receive messages, you need to register a message handler using the `RegisterMessageHandler` method of the `QueueClient` or `SubscriptionClient` class.
 
    ![image](https://github.com/jil1710/ASB/assets/125335932/d6f2bf60-8ed1-46a3-b9f5-2cd668a1e598)
  ![image](https://github.com/jil1710/ASB/assets/125335932/e7ec6aa0-dec1-431e-8b6e-8cd008f1a2d0)








