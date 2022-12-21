Soliterax Library


The purpose of this library is to provide convenience in coding completely. It combines everything from File Recording System to connecting to Database systems and data processing and allows you to write the fastest code.

FileSystem Usage Guide

Register Reference
SoliteraxLibrary.FileSystem.SoliteraxFile file = new SoliteraxLibrary.FileSystem.SoliteraxFile(path);

Get File First data
file.Read(); return String veriable

get all data from file
file.ReadAll(); return string[] veriable


SQLSystem Usage Guide

Is there 3 class registered this system
ConnectDatabase
DatabaseManager
DatabaseStorage

ConnectDatabase class provide sql connection and handle their classes
DatabaseManager provide sql execution
DatabaseStorage store data in history

how to connect DAtabase

SoliteraxLibrary.SQLSystem.ConnectDatabase db = new SoliteraxLibrary.SQLSystem.ConnectDatabase(connectionString, ConnectionType);

This library Connect to 3 database service
    - SQL
    - MySQL
    - OleDB
You switch this from ConnectionType enum class
ConnectionType.SQL
ConnectionType.MySQL
ConnectionType.OleDB

and this library provide new create connection string method
SoliteraxLibrary.SQLSystem.ConnectDatabase.CreateConnectionString(hostIp, databasename, charset, username, password, ConnectionType);
this method auto generate connectionstring

if you connect SQL Database

using System;
using System.Data;
using SoliteraxLibrary;
using SoliteraxLibrary.SQLSystem;

namespace MyApp{
  
  public class MyApp1{
    
    ConnectDatabase db = new ConnectDatabase(ConnectDatabase.CreateConnectionString("test.ip.com", "testdata", 'UTF-8', 'testuser', 'testpassword', ConnectionType.SQL), ConnectionType.SQL);
    public static void main(string[] args){
        
      //if you get data from database
      
      DatabaseManager dm = db.GetManager();
      DataTable dt = dm.GetData("select * from denemetable");
      
      for(int i = 0; i < dt.Rows.Count; i++) {
      
        Console.WriteLine(dt.Rows[i][0].ToString() + " - " + dt.Rows[i][1].ToString() + ...);
        
      }
      
      //if you send no return sql data
      
      dm.SendData("insert into denemetable(id, name) values (2, 'DenemeName')");
      
      and if your work is finished with database you can disconnecting the library 
      db.DisConnect();
      
    }
    
  }
  
}

I am currently working Server System
Thank you for your reading this text my english is bad and I am sorry for this problem
Please forgive me for bad english word creating
