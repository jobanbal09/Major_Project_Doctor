Add-migration Auth -Context ApplicationDBContext
 update-database Auth -Context ApplicationDBContext
   Add-migration Doctor -Context Major_Project_DoctorContext
   update-database Doctor -Context Major_Project_DoctorContext