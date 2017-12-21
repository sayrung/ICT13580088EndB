﻿using System;
using System.Collections.Generic;
using ICT13580088EndB.Model;
using Xamarin.Forms;

namespace ICT13580088EndB
{
    public partial class ProductNewPage : ContentPage
	{
		Product product;
		public ProductNewPage(Product product = null)
		{
			InitializeComponent();
			this.product = product;
			titleLable.Text = product == null ? "เพิ่มประวัติใหม่" : "แก้ไขรายชื่อ";

			saveButton.Clicked += SaveButton_Clicked;
			cancelButton.Clicked += CancelButton_Clicked;

			typePicker.Items.Add("เก๋ง");
			typePicker.Items.Add("มอไซต์");
            typePicker.Items.Add("กระบะ");

			brandPicker.Items.Add("โตโยต้า");
			brandPicker.Items.Add("ฮอนด้า");
			brandPicker.Items.Add("ฮุนไดร์");

			colorPicker.Items.Add("แดง");
			colorPicker.Items.Add("ฟ้า");

			addressPicker.Items.Add("กรุงเทพ");
			addressPicker.Items.Add("เชียงใหม่");
			addressPicker.Items.Add("เลย");
			addressPicker.Items.Add("ชุมพร");
			addressPicker.Items.Add("แพร่");


			yearStepper.ValueChanged += YearStepper_ValueChanged1;
			if (product != null)
			{
				typePicker.SelectedItem = product.Typecar;
				brandPicker.SelectedItem = product.Brand;
				modelEntry.Text = product.Model;
				mileEntry.Text = product.Mile;
				colorPicker.SelectedItem = product.Color;
				delarEntry.Text = product.Deler;
				detailEditor.Text = product.Deital.ToString();
				priceEntry.Text = product.Price;
				addressPicker.SelectedItem = product.Address;
				telEntry.Text = product.Tel;


			}


		}

		void YearStepper_ValueChanged1(object sender, ValueChangedEventArgs e)
		{
			int value = (int)e.NewValue;
			yearLabel.Text = value.ToString();
		}



		async void SaveButton_Clicked(object sender, EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบัญทึกใช่หรือไม่", "ใช่", "ไม่ใช่");

			if (isOk)
			{
				if (product == null)
				{
					product = new Product();

					product.Typecar = typePicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
					product.Model = modelEntry.Text;
					product.Mile = mileEntry.Text;
					product.Color = colorPicker.SelectedItem.ToString();
					product.Deler = delarEntry.Text;
					product.Deital = detailEditor.Text;
					product.Price = priceEntry.Text;
					product.Address = addressPicker.SelectedItem.ToString();
					product.Tel = telEntry.Text;


					var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ" + id, "ตกลง");
				}



				else
				{
					product.Typecar = typePicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
					product.Model = modelEntry.Text;
					product.Mile = mileEntry.Text;
					product.Color = colorPicker.SelectedItem.ToString();
					product.Deler = delarEntry.Text;
					product.Deital = detailEditor.Text;
					product.Price = priceEntry.Text;
					product.Address = addressPicker.SelectedItem.ToString();
					product.Tel = telEntry.Text;

					var id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้า" + id, "ตกลง");
				}
				await Navigation.PopModalAsync();
			}
		}

		void CancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}
	}
}