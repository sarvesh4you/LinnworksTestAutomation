btn_reviewHeader						xpath					 //div[@id='Review']//table//button[@title='${title}']
lnk_scriptNumber						xpath					 //div[@class='review-table']//table//tr[${num}]/td[contains(@class,'scriptnum')]
lnk_serialNumber						xpath					 //div[@class='review-table']//table//tr[${num}]/td[contains(@class,'sernum')]
lnk_claimNumber 						xpath					 //div[@class='review-table']//table//tr[${num}]/td[contains(@class,'claim')]
lnk_docs								xpath					 //div[@class='review-table']//table//tr[contains(.,'${scriptNo}')]/td[contains(@class,'docs')]
input_checkbox							xpath					 //div[@class='review-table']//table//tr[${num}]/td[contains(@class,'checkbox')]//input
lnks_allreviewColumns					xpath					 //div[@class='review-table']//table//tr/td[contains(@class,'${name}')]
lnks_allScripts				        	xpath					 //div[@class='review-table']//table/tbody/tr[@class='scan-item-row']
lnk_givenScript							xpath					 //div[@class='review-table']//table//tr[contains(.,'${scriptNo}')]/td[contains(@class,'scriptnum')]
input_scriptNumber						id						 UpdateScriptNumber
input_serialNumber						id						 UpdateRefNumber
input_category							xpath					 //form//span[text()='${category}']
btn_category						    xpath					 //button[@data-id="UpdateCategory"]
btn_saveChanges							xpath					 //button[contains(@class,'save-changes')]
btn_ok									xpath					 //button[text()='OK']
msg_errorExistingInfo					id					     swal2-content
lnk_claimStatus							xpath					 //button[@title='${title}']
input_searchField						id						 search-script
btn_applyFilters						id						 apply-filters
msg_noRecords							id						 no-records-found
head_email								xpath					 //div[@id="EmailScriptsModal"]//h4[contains(.,"Email Script(s)")]
lbl_email								xpath					 //div[@id="EmailScriptsModal"]//div[@class="modal-body"]//label[contains(.,"${label}")]
field_ToEmail							xpath					 //div[@id="EmailScriptsModal"]//div[@class="modal-body"]//label[contains(.,"To")]//following-sibling::div
btn_sendCancel							xpath					 //*[@id='EmailScriptsModal']//button[contains(text(),'${name}')]
txt_attachments							id						 Attachments
btn_closeEmail							xpath					 //*[@id='EmailScriptsModal']//button[@class='close']
colHeading_auditLog					    xpath					 //div[@id='AuditTable']/table/thead/tr[2]/th[text()='${name}']
original_auditLogHeader				    xpath					 //div[@id='AuditTable']/table/thead/tr[3]/th[contains(@data-field,'Before')and text()='${name}']
updated_auditLogHeader					xpath					 //div[@id='AuditTable']/table/thead/tr[3]/th[contains(@data-field,'After')and text()='${name}']
heading_modified						xpath                    //div[@id='AuditTable']/table/thead/tr[3]/th[contains(@data-field,'Modified') and contains( text(),'${name}')]
value_delOn_AuditLog					xpath					 //div[@id='AuditTable']//table//tr[${text}]//td[@class='del diff']
value_auditLog							xpath					 //*[@id='AuditTable']/table/tbody/tr[1]/td[contains(@class,'${class}')]
chkbox_selectAllScripts					xpath					 //input[@class='select-all-claims']
scriptNumber							xpath					 //td[@class='td-scriptnum' and text()='${text}']
alert_refresh							xpath					 //div[@class='swal2-container swal2-fade swal2-shown']
heading_moveClaim						id						 swal2-title	
dropdown_moveClaim						xpath					 //select[@class="swal2-select"]
btn_MoveClaimCancel						xpath					 //button[@class="swal2-cancel swal2-styled" and text()='Cancel']
btn_sendEmail							xpath					 //button[@class="btn btn-default confirm-button send-email"]
txt_NoScriptSelected					xpath					 //h3[text()='No Script Selected']
btn_Right			      				xpath					 //button[@class='blob-moveright btn btn-default btn-xs']
btn_Left 			    				xpath					 //button[@class='blob-moveleft btn btn-default btn-xs']
txt_docIndex							xpath					 //object[@id="ScanPdf"]
btn_delete_pdfHeader					xpath					 //div[@class="panel-heading pdf-header"]//button[@title='Delete']
alert_confirmDelete						xpath					 //h2[@id='swal2-title' and text()='Confirm Delete']
msg_alertDelete							xpath					 //div[@id='swal2-content']	
icon_claimStatus						xpath					 //td[contains(@class,'icon')]//i
dropdown_claimCategory					xpath					 //div[@id="divClaimCategory"]//button[@data-id="ddlCategory"]
dropdownValues_claimCategory			xpath					 //div[@id="divClaimCategory"]//ul[@class="dropdown-menu inner"]//li//span[@class="text" and text()='${text}']
txt_allSerialNo							xpath					 //div[@class='review-table']//table//tr/td[contains(@class,'sernum')]

lnk_withDynamicText			      	    xpath				     //a[text()='${text}']
lnk_option                              xpath                    //option[text()='${claim}']
lnk_subsection_CPS						xpath					 //a[contains(.,'${title}')]
lnk_claimPeriods						xpath					 //select[@id='SelectClaimPeriod']//option
btn_All_claimPeriod						xpath					 //button[@data-id="SelectClaimPeriod"]
txt_noOfScript							xpath					 //span[text()='${text}']//following-sibling::div/span
btn_home								xpath					 //a[contains(@title,"Home")]
txt_scannedScripts                      xpath                    //mat-row[1]//mat-cell[2]
txt_uploadedScripts                     xpath                    //mat-row[2]//mat-cell[2]
txt_rejectedScripts						xpath					 //mat-row[4]//mat-cell[2]
btn_review                              xpath                    //button[text()='Review']