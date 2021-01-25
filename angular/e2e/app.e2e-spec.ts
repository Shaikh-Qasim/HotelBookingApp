import { HotelBookingAppTemplatePage } from './app.po';

describe('HotelBookingApp App', function() {
  let page: HotelBookingAppTemplatePage;

  beforeEach(() => {
    page = new HotelBookingAppTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
