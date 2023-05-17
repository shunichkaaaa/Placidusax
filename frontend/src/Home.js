import React, { Component } from "react";
import { Container, Button, Row, Col, Image, Card } from "react-bootstrap";
import company from "./company.jpg";

export class Home extends Component {
  render() {
    return (
      <div className="App">
        <main>
          <Container>
            <Row className="px-4 my-5">
              <Col sm={6}>
                <Image
                  src={company}
                  alt="Company photo"
                  fluid
                  rounded
                  className=""
                />
              </Col>
              <Col sm={6}>
                <h1 class="font-weight-light">Company description</h1>
                <p class="mt-4">
                  Welcome to Placidusax, a leading company of talented
                  programmers and software engineers dedicated to pushing the
                  boundaries of technology and creating groundbreaking
                  solutions. Our team is committed to delivering top-notch
                  software development services that transform ideas into
                  reality.
                  <br></br>
                  Placidusax embraces a diverse range of projects, spanning web
                  development, mobile app development, cloud solutions,
                  artificial intelligence, machine learning, and more. We are
                  continuously honing our skills and staying ahead of the curve
                  in the ever-evolving tech landscape. <br></br>
                  When you choose Placidusax as your software development
                  partner, you gain access to a team of exceptional programmers
                  who are dedicated to your success. We take pride in our
                  ability to transform ideas into high-quality, user-friendly
                  software solutions that drive growth, streamline operations,
                  and amplify business outcomes.
                  <br></br>Join us at Placidusax and let's unlock the power of
                  technology together!
                </p>
                <Button
                  variant="outline-primary"
                  href="https://github.com/shunichkaaaa/Software-engineering"
                >
                  Open repository
                </Button>
              </Col>
            </Row>
            <Card className="text-center bg-secondary text-white my-5 py-4">
              <Card.Body>
                Placidusax offers an exclusive online platform designed
                specifically for the convenience and fast-accessible storage of
                our valued employees. Placidusax Employee Storage is a secure
                and user-friendly website that provides our team administrators
                with a seamless experience for managing and accessing their
                workers information.
              </Card.Body>
            </Card>
          </Container>
        </main>
        <footer class="py-5 my-5 bg-dark">
          <Container className="px-4">
            <p className="text-center text-white">
              Copyright &copy; Placidusax employees storage 2023
            </p>
          </Container>
        </footer>
      </div>
    );
  }
}
