# HubSection-FillPage-Behavior
A Behavior to make the UWP Hub control adjust the width of each HubSection to fill the Hub width. It will also snap in place when swiped.

##Goal
When Windows 10 Mobile came out, the Hub control functionality was quite different than the Windows Phone 8.1 control. 
There were two main differencies. 
- The HubSections no longer fit the width of the screen by default
- The HubSections no longer snapped in place when swiped

The intention of this behavior is to give the above functionality to the UWP Hub control when running on a mobile device.


##Usage
```
<!-- use the necessary namespaces -->
<Page
 xmlns:Interactivity="using:Microsoft.Xaml.Interactivity" 
 xmlns:HubSectionFillPage="using:HubSectionFillPageBehavior"
>
		...
		
		<!-- Attach the behavior to the Hub -->
		 <Hub>
            <Interactivity:Interaction.Behaviors>
                <HubSectionFillPage:HubSectionFillPageBehavior/>
            </Interactivity:Interaction.Behaviors>           
		
		... HubSections here
		
		</Hub>
		
		...

</Page>

```


##Functionality
This behavior changes the default functionality of the UWP Hub control **only when running on a mobile device**. 
It will not affect the control when running on a different device familly. 

When using this behavior each HubSection will occupy the whole width of the parent Hub minus a small margin to allow the next HubSection to be visible.
The last HubSection will not have this margin.

Also, when swiping the next HubSection will snap into place.


## Installing
Download and build the solution, then reference the dll in your project

OR

Copy and Paste the code.
In this case you will need to reference the [Xaml Behaviors SDK](https://github.com/Microsoft/XamlBehaviors) in your project.

**Nuget: Coming Soon**

## Contribution
If anyone has a good idea to improve this behavior I will be glad to accept pull requests.
I'm particularly interested in providing the ability to swipe from the last HubSection to the first in a cycle.

##Licence 

This code is licenced under the MIT Licence - see the [LICENCE](https://github.com/corcus/HubSection-FillPage-Behavior/blob/master/LICENSE) file for details
