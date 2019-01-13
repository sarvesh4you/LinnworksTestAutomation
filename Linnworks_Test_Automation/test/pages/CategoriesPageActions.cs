using NUnit.Framework;
using OpenQA.Selenium;

namespace LinnworksTests
{
    public class CategoriesPageActions: GetPage
    {
     
        public CategoriesPageActions(IWebDriver driver) : base("CategoriesPage", driver)
        {

        }

      
        public void createNewCategory(string newCategory)
        {
           
            click(element("lnk_createNew"));
            logMessage("User clicked on the 'Create New' link on the top.");

            isElementDisplayed("txtfld_name");
            sendText(element("txtfld_name"), newCategory);
            logMessage("User entered '" + newCategory + "' in the Name textfield.");

            click(element("btn_save"));
            logMessage("User clicked on 'Save' button");

        }


        public void verifyUserIsOnCategoriesPage()
        {
            Assert.IsTrue(isElementDisplayed("heading_categories"), "ASSERTION FAILED : 'Categories' heading is not displaying.");
            logMessage("ASSERTION PASSED : 'Categories' heading is displaying on the top of the page.");
        }


        public void verifyCategoryIsDisplayingOnCategoriesPageList(string categoryName)
        {
            Assert.IsTrue(isElementDisplayed("element_withDynamicText", categoryName), "ASSERTION FAILED : Category "+ categoryName + " is not displaying in the categories list.");
            logMessage("ASSERTION PASSED :  Category " + categoryName + " is displaying in the categories list.");
        }


        public  void editAnExistingCategory(string newCategoryName, string editedCategoryName)
        {
            click(element("btn_editForCategory", newCategoryName));
            logMessage("User clicked on the 'Edit' link for the category.");

            isElementDisplayed("txtfld_name");
            sendText(element("txtfld_name"), editedCategoryName);
            logMessage("User entered '" + editedCategoryName + "' in the Name textfield.");

            click(element("btn_save"));
            logMessage("User clicked on 'Save' button");

        }


        public void verifyCategoryIsNotDisplayingOnCategoriesPageList(string categoryName)
        {
            Assert.IsTrue(isElementNotDisplayed("element_withDynamicText", categoryName), "ASSERTION FAILED : Category " + categoryName + " is still displaying in the categories list.");
            logMessage("ASSERTION PASSED :  Category " + categoryName + " is successfully deleted from the categories list.");
        }


        public void deleteAnExistingCategory(string categoryNameToBeDelete)
        {
            click(element("btn_deleteForCategory", categoryNameToBeDelete));
            logMessage("User clicked on the 'Delete' link for the category.");
            handleAlert();
        }
   
    }
}