import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { About } from "./pages/about/about";
import { Header } from "./pages/header/header";
import { Footer } from "./pages/footer/footer";
import { Home } from "./pages/home/home";
import { ContactUs } from "./pages/contact-us/contact-us";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, About, Header, Footer, Home, ContactUs],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('SmartCertify_UI');
}
