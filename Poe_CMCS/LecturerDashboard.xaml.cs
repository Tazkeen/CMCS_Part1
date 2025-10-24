using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace ClaimManagement
{
    public partial class LecturerDashboard : Window
    {
        private string uploadedFilePath = "";

        public LecturerDashboard()
        {
            InitializeComponent();
            this.DataContext = ClaimsDataModel.Instance;
            claimsDataGrid.ItemsSource = ClaimsDataModel.Instance.ClaimList;
        }

        // ✅ Handle file upload safely
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Word Documents (*.docx)|*.docx|Excel Files (*.xlsx)|*.xlsx";
                if (openFileDialog.ShowDialog() == true)
                {
                    uploadedFilePath = openFileDialog.FileName;
                    uploadedFileNameTextBlock.Text = $"Uploaded: {System.IO.Path.GetFileName(uploadedFilePath)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting file: {ex.Message}", "Upload Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // ✅ Handle claim submission safely
        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = nameTextBox.Text;
                string surname = surnameTextBox.Text;
                string hoursWorked = hoursWorkedTextBox.Text;
                string hourlyRate = hourlyRateTextBox.Text;
                string additionalNotes = notesTextBox.Text;

                if (string.IsNullOrWhiteSpace(hoursWorked) || string.IsNullOrWhiteSpace(hourlyRate))
                {
                    MessageBox.Show("Please fill in all required fields (Hours Worked and Hourly Rate).");
                    return;
                }

                ClaimsDataModel.Instance.ClaimList.Add(new Claim
                {
                    ClaimID = (ClaimsDataModel.Instance.ClaimList.Count + 1).ToString(),
                    FirstName = firstName,
                    Surname = surname,
                    HoursWorked = hoursWorked,
                    HourlyRate = hourlyRate,
                    AdditionalNotes = additionalNotes,
                    SupportingDocument = uploadedFilePath,
                    Status = "Pending"
                });

                MessageBox.Show("Claim submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear form
                nameTextBox.Clear();
                surnameTextBox.Clear();
                hoursWorkedTextBox.Clear();
                hourlyRateTextBox.Clear();
                notesTextBox.Clear();
                uploadedFileNameTextBlock.Text = "";
                uploadedFilePath = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting claim: {ex.Message}", "Submission Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Back button
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
