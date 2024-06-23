Flood Monitoring Application
Overview
------------------
The Flood Monitoring Application is designed to help monitor water levels at various stations to predict and warn about potential flood and drought conditions. This application includes features for real-time data visualization, alert configurations, and historical data analysis.

Features
------------------
Real-time Monitoring: Continuously tracks water levels at various stations.
Alert Configurations: Allows setting flood and drought warning values for each station.
Data Visualization: Displays the current water levels with color-coded alerts on the main page.
Historical Data Analysis: Provides a graph of the last 5 measurements for each station in the details view.
Timeout Configuration: Configures the maximum allowed time without data before flagging an error.

Usage
------------------
Main Page: Lists all monitoring stations with their current water levels.
Station Details: Click on a station's details to view historical data and a graph of the last 5 measurements.
Alert Colors:
Red: Indicates the water level has reached or exceeded the flood warning value.
Orange: Indicates the water level is below the drought warning value.
White: Indicates normal water levels.

Configuration
------------------
Time Tolerance: Configurable timeout for data reception to determine if the station data is outdated. This can be set during station creation or in the configuration file.
