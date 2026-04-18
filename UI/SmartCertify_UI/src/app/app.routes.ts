import { Routes } from '@angular/router';
import { Home } from './pages/home/home';

export const routes: Routes = [
    {
        path: "",
        redirectTo: "home",
        pathMatch: "full"
    },
    {
        path: "home",
        component: Home
    },
    {
        path: "data-bindings",
        loadComponent: () => import("./components/data-bindings/data-bindings").then(m => m.DataBindings)
    },
    {
        path: "about",
        loadComponent: () => import("./pages/about/about").then(m => m.About)
    },
    {
        path: "contact",
        loadComponent: () => import("./pages/contact-us/contact-us").then(m => m.ContactUs)
    },
    {
        path: "**",
        redirectTo: "home"
    }
];
