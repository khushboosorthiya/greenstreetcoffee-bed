# Green Street Coffee

## Requirements

### Header Component

  - Reference website - https://www.greenstreetcoffee.com/
  - Functional Requirements:
    - It is a two level navigation with primary links and sub-navigation links. If user hovers on primary link, it expands child items flyout underneath. When user clicks outside flyout closes.
    - There is logo of the company. When user clicks on logo, it will take to the homepage of the site. Search bar and cart icon are statis now as mentioned.
  - Sitecore Requirements:
    - All items in first level of navigation named "Shop Coffee" , "Overview", "Philosophy", "Classes", "Brew Guides" are parent items in Sitecore. 
    - When user hovers on each of these parent items, child items flyout opens, maintain this parent child relationship also in Sitecore. 
    - It should be possible for authors to change items in navigation and they should have possibility to choose some other item in navigation from experience editor at any point. 
    - Everything should be editable in experience editor.
    - Header navigation it should be rendered on all pages in your site.

## Tools and Technologies

  - Sitecore Experience Platform - Version 10.2
  - Visual Studio 2022
  - Visual Studio Code
  - Sitecore CLI for items serialization
  - Sitecore MVC
  - Frontend Repo: https://github.com/khushboosorthiya/greenstreetcoffee-fed
    - HTML, CSS, SASS, Bootstrap, Gulp

## Screenshot

![Greenstreet Coffee Roasters](https://user-images.githubusercontent.com/35101171/182627003-ecb300a5-59e7-42a0-b64c-ea6d7db513e0.png)


